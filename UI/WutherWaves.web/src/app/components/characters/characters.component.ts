import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-characters',
  standalone: true,
  imports: [],
  templateUrl: './characters.component.html',
  styleUrl: './characters.component.css'
})
export class CharactersComponent {

    constructor(){

    }
    ngOnInit(){
      this.getCharacters();
    }
    getCharacters(){
    
    }
}
