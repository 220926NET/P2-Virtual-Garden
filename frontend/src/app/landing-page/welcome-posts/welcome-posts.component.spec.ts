import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomePostsComponent } from './welcome-posts.component';

describe('WelcomePostsComponent', () => {
  let component: WelcomePostsComponent;
  let fixture: ComponentFixture<WelcomePostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomePostsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WelcomePostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
