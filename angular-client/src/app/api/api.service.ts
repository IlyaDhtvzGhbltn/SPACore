import {Order, OrderComponent} from "src/app/order/order.component"
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable({providedIn:'root' })
export class ApiService{
  private API = 'https://localhost:44336/api/v1/orders'
  private Headers = new HttpHeaders({'Content-Type': 'application/json'})


  constructor(private httpclient: HttpClient) {
  }
  getOrders():Observable<Order[]> {
    return this.httpclient.get<Order[]>(
      this.API);
  }

  deleteOrder(id: number){
    const url = `${this.API}/${id}`
    return this.httpclient.delete(url)
  }

  addOrder(order: Order){
    order.date = new Date().toJSON()
    const options = { headers: this.Headers }
    const json = JSON.stringify(order)
    this.httpclient.post(this.API, json, options)
      .subscribe(resp => {
        console.log(resp)
      })
  }
}
