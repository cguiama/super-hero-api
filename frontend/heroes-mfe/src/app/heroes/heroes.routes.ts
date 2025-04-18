import { Routes } from '@angular/router';
import { HeroListComponent } from './pages/hero-list/hero-list.component';
import { HeroCreateComponent } from './pages/hero-create/hero-create.component';
import { HomePageComponent } from './pages/home-page/home-page.component';

export const HEROES_ROUTES: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'heroes',
    component: HeroListComponent,
  },
  {
    path: 'heroes/create',
    component: HeroCreateComponent,
  },
];
