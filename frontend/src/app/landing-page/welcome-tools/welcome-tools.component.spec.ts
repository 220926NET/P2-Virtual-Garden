import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeToolsComponent } from './welcome-tools.component';

describe('WelcomeToolsComponent', () => {
  let component: WelcomeToolsComponent;
  let fixture: ComponentFixture<WelcomeToolsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeToolsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WelcomeToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
