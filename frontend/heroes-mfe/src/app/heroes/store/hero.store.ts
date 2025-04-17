import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Hero } from '../models/hero.model'; 
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeroStore {

  private readonly baseUrl = 'http://localhost:5260/api/Heroes'; 

  private readonly heroes = signal<Hero[]>([]);
  readonly heroesSignal = this.heroes.asReadonly();

  constructor(private readonly http: HttpClient) {}

  // Carregar todos os heróis do backend
  loadHeroesFromApi() {
    this.http.get<Hero[]>(this.baseUrl)
      .pipe(
        catchError(err => {
          console.error('Erro ao carregar heróis:', err);
          return of([]); // Retorna lista vazia em caso de erro
        })
      )
      .subscribe(heroes => {
        this.heroes.set(heroes);
      });
  }

  // Adicionar novo herói no backend e atualizar a lista
  addHeroToApi(hero: Hero) {
    this.http.post<Hero>(this.baseUrl, hero)
      .pipe(
        catchError(err => {
          console.error('Erro ao adicionar herói:', err);
          return of(null);
        })
      )
      .subscribe(newHero => {
        if (newHero) {
          this.heroes.update(current => [...current, newHero]);
        }
      });
  }

  
  clearHeroes() {
    this.heroes.set([]);
  }
}
