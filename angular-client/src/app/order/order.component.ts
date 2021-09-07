import {Component, OnInit} from "@angular/core";
import {ApiService} from "../api/api.service";

export interface Order{
  id: number
  company: string
  customer: string
  minister: string
  date: string
  email: string
  edit : boolean
}

@Component({
  selector: 'order-items',
  templateUrl: 'order.component.html',
  styleUrls: ['order.component.css']
})
export class OrderComponent implements  OnInit{
  constructor(private api: ApiService) {
  }

  public orders: Order[] = [];
  ngOnInit(){
    this.api.getOrders()
      .subscribe(data=>
      {
        data.forEach(x => x.edit = false)
        this.orders = data
        this.api.newOrderAddedEvent
          .subscribe(order =>
          {
            order.edit = false;
            this.orders.push(order)
          } )
      });
  }

  onRemove(id: number){
    this.api.deleteOrder(id)
      .subscribe(() => this.orders = this.orders.filter(x => x.id !== id));
  }

  onEdit(order: Order){
    this.api.editOrder(order)
      .subscribe(resp => {
        this.orders.forEach(x => {
          if(x.id == order.id){
            x.edit = false
          }
        })
      })
  }
}
