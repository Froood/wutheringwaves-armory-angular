import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Characters } from '../../models/characters.model';

@Injectable({
  providedIn: 'root'
})
export class CharactersService {

  constructor(private http:  HttpClient) { 

  }
  
  getAllCharacters(){
    return this.http.get<Characters[]>('https://localhost:7278/api/Characters');
  }
}
