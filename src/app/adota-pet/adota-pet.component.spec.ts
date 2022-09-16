import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdotaPetComponent } from './adota-pet.component';

describe('AdotaPetComponent', () => {
  let component: AdotaPetComponent;
  let fixture: ComponentFixture<AdotaPetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdotaPetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdotaPetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
