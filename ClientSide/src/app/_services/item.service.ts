import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(
    public http: HttpClient
  ) { }

  getItems(){
    return this.http.get('https://localhost:44303/api/item');
  }
}
