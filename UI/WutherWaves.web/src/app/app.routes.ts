import { Routes } from '@angular/router';
import { CharactersComponent } from './components/characters/characters.component';
import { HomeComponent } from './components/home/home.component';


export const routes: Routes = [

    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'characters', component: CharactersComponent },

];
