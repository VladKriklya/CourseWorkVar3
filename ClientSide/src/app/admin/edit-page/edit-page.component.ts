import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/_services/item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-page',
  templateUrl: './edit-page.component.html',
  styleUrls: ['./edit-page.component.scss']
})
export class EditPageComponent implements OnInit {
  itemList = [];
  itemTempList = [];
  tempArray = [];

  constructor(
    public itemService: ItemService,
    public router: Router
  ) { }

  ngOnInit(): void {
    this.itemService.getItems()
      .subscribe(res => this.itemList = this.itemTempList = res as []);
  }

  getCups(index : number){
    this.itemList = this.itemTempList;
    this.tempArray = [];
    this.itemList.forEach((el) => {
      if(el.category == index){
        this.tempArray.push(el);
      }
    })
    this.itemList = this.tempArray;
  }

  getAllCups(){
    this.itemList = this.itemTempList;
  }

  cancel(){
    this.router.navigate(['/']);
  }

  Edit(id: number){
  /*  if (id == null)
      return;
    else if (confirm('Are you sure to delete this record ?'))
     this.itemService.editItem(id);*/
  }

  Delete(id: number){
   /*if (id == null)
      return;
    else if (confirm('Are you sure to delete this record ?'))
      this.itemService.deleteItem(id);
    */
  }

  searchItem(id){

  }
}


