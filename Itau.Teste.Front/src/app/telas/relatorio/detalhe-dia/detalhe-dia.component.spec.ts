import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalheDiaComponent } from './detalhe-dia.component';

describe('DetalheDiaComponent', () => {
  let component: DetalheDiaComponent;
  let fixture: ComponentFixture<DetalheDiaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalheDiaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalheDiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
