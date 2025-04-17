import { Routes } from '@angular/router';
import { HeroListComponent } from './pages/hero-list/hero-list.component';

export const HEROES_ROUTES: Routes = [
  {
    path: '',
    component: HeroListComponent,
  },
];
