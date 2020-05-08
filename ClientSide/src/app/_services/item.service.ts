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

  addItem(item){
    return this.http.post('https://localhost:44303/api/item', item);
  }

  editItem(id){
    return this.http.put('https://localhost:44303/api/item', id);
  }

  deleteItem(id){
    return this.http.delete('https://localhost:44303/api/item', id);
  }
}
