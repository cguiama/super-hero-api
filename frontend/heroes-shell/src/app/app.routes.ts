import { provideHttpClient } from '@angular/common/http';
import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'heroes',
    loadChildren: () => import('heroesMfe/HeroesRoutes').then(m => m.HEROES_ROUTES),
    providers: [provideHttpClient()], 
  },
  {
    path: '',
    redirectTo: 'heroes',
    pathMatch: 'full',
  },
];
