import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetTrackComponent } from './pet-track.component';

describe('PetTrackComponent', () => {
  let component: PetTrackComponent;
  let fixture: ComponentFixture<PetTrackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PetTrackComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PetTrackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
