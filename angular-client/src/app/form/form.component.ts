import {Component, OnInit} from "@angular/core";
import {Order} from "../order/order.component";
import {ApiService} from "../api/api.service";

@Component({
  selector: 'new-order-form',
  templateUrl: 'form.component.html',
  styleUrls: ['form.component.css']
})

export class FormComponent implements OnInit{
  constructor(private api: ApiService) {
  }

  ngOnInit() {
  }

  public order: Order = { id:0, email: '', company: '', minister: '', customer:'', date:''}
  onAdd(){
    this.api.addOrder(this.order)
  }
}
