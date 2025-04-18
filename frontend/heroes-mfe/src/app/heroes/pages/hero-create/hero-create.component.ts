import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SuperpowerService } from '../../services/superpower.service';
import { SuperPower } from '../../models/superpower.model';

@Component({
  selector: 'app-hero-create',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [SuperpowerService],
  templateUrl: './hero-create.component.html',
  styleUrls: ['./hero-create.component.scss']
})
export class HeroCreateComponent implements OnInit {

  heroForm!: FormGroup;
  superPowers: SuperPower[] = [];

  constructor(
    private readonly fb: FormBuilder,
    private readonly superpowerService: SuperpowerService
  ) {}

  ngOnInit() {
    this.heroForm = this.fb.group({
      name: ['', Validators.required],
      heroName: ['', Validators.required],
      birthDate: ['', Validators.required],
      height: [0, [Validators.required, Validators.min(0)]],
      weight: [0, [Validators.required, Validators.min(0)]],
      superPowerIds: this.fb.array([]) // array reativo para superpoderes
    });

    this.loadSuperPowers();
  }

  get superPowerIdsFormArray() {
    return this.heroForm.get('superPowerIds') as FormArray;
  }

  getFormControlAt(index: number): FormControl {
    return this.superPowerIdsFormArray.at(index) as FormControl;
  }

  loadSuperPowers() {
    this.superpowerService.getSuperPowers().subscribe((powers: SuperPower[]) => {
      this.superPowers = powers;
      powers.forEach(() => this.superPowerIdsFormArray.push(this.fb.control(false)));
    });
  }

  onSubmit() {
    if (this.heroForm.valid) {
      const selectedPowerIds = this.superPowers
        .filter((_, index) => this.superPowerIdsFormArray.at(index).value)
        .map(p => p.id);

      const heroData = {
        ...this.heroForm.value,
        superPowerIds: selectedPowerIds
      };

      console.log('Dados para salvar:', heroData);
      // Aqui futuramente a gente faz o POST na API!
    }
  }
}
