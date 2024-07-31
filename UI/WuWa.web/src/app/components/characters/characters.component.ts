import { Component } from '@angular/core';
import { Characters } from '../../../models/characters.model';
import { HttpClient} from '@angular/common/http';
import { CharactersService } from '../../services/characters.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrl: './characters.component.css'
})
export class CharactersComponent {

  characters: Characters[] = [];

  constructor(private cService: CharactersService, private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.getCharacters();
  }

  getCharacters() {
    this.cService.getAllCharacters().subscribe({
      next: (res) => {
        debugger;
        this.characters = res;
        // Handle the response here
      },
      error: (err) => {
        debugger;
        console.error('Error occurred:', err);
      },
    });
  }

  goToRoute(){
    this.router.navigateByUrl('/home');
  }
}
