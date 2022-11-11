import { Component, OnInit, Renderer2 } from '@angular/core';
import { UrlHandlingStrategy } from '@angular/router';
import { Guid } from 'guid-typescript';
import { GardenService } from '../core/garden.service';
import { IGarden } from '../shared/interface';


@Component({
  selector: 'app-garden-grid',
  templateUrl: './garden-grid.component.html',
  styleUrls: ['./garden-grid.component.css']
})
export class GardenGridComponent implements OnInit {
  barbGuid: string = "11dc56fa-0841-42d7-b6e2-e793ed2ec2ce";
  garden: IGarden = {
    id: Guid.EMPTY,
    user_id: this.barbGuid,
    tiles: []
  }

  constructor(private gservice: GardenService, private renderer: Renderer2) { }

  doRender(): void {
    console.log(this.garden);
    for (let i = 0; i < 16; i++) {
      const element: HTMLElement | null = document.getElementById("t" + i);
      this.renderer.setStyle(element, "background-image", `url(assets/${this.garden.tiles[i].plant_information.image_path})`);
      this.renderer.setStyle(element, "background-size", "100%");
      this.renderer.setStyle(element, "background-repeat", "no-repeat");
    }
  }

  ngOnInit(): void {
    sessionStorage.setItem('selectedTool', 'nothing');
    // See if there is a garden saved
    this.gservice.getGarden(this.garden.user_id).subscribe({
      next: (res) => {
        // Garden found in database set that to render
        this.garden = res;
        this.doRender();
      },
      error: (err) => {
        // Garden not found try to create one
        this.gservice.addGarden(this.garden).subscribe({
          next: (res) => {
            // Set the created garden to render
            this.garden = res;
            this.doRender();
          },
          error: (err2) => {
            // Unable to create garden, log this error
            console.error(err2);
          }
        });
      },
    });
  }

  GetTileId(e: Event): void {
    let elementId: string = (e.target as Element).id;
    this.gservice.getPlant(sessionStorage.getItem('selectedTool')!).subscribe({
      next: (res) => {
        let tileId: string = elementId.substring(1, elementId.length);
        this.garden.tiles[Number.parseInt(tileId)].plant_information.id = res;
        this.gservice.updateGarden(this.garden).subscribe({
          next: (res) => {
            this.garden = res;
            this.doRender();
          },
          error: (err) => { console.error(err); }
        })
      },
      error: (err) => { console.error(err) }
    })
  }



}
