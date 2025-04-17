import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HeroStore } from '../../store/hero.store';

@Component({
  selector: 'app-hero-list',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [HeroStore], // <- Aqui
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.scss']
})

export class HeroListComponent {

  constructor(public heroStore: HeroStore) {}

  ngOnInit() {
    this.heroStore.loadHeroesFromApi();
  }

}
