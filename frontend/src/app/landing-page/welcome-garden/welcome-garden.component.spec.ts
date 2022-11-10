import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeGardenComponent } from './welcome-garden.component';

describe('WelcomeGardenComponent', () => {
  let component: WelcomeGardenComponent;
  let fixture: ComponentFixture<WelcomeGardenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeGardenComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WelcomeGardenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
