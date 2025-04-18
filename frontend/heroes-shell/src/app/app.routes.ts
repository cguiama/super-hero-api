import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('heroesMfe/HeroesRoutes').then(m => m.HEROES_ROUTES),
  },
];
