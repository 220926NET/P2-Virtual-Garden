import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GardenGridComponent } from './garden-grid.component';

describe('GardenGridComponent', () => {
  let component: GardenGridComponent;
  let fixture: ComponentFixture<GardenGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GardenGridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GardenGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
