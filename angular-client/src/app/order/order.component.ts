import {Component, OnInit} from "@angular/core";
import {ApiService} from "../api/api.service";

export interface Order{
  id: number
  company: string
  customer: string
  minister: string
  date: string
  email: string
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
      .subscribe(data=> this.orders = data);
  }

  onRemove(id: number){
    this.api.deleteOrder(id)
      .subscribe(() => this.orders = this.orders.filter(x => x.id !== id));
  }
}
