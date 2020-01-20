import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']

})
export class TransactionsComponent {
  public transactions: Transaction[];
  public key: string = 'date';
  public reverse: boolean = false;
  public page: number = 1;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Transaction[]>(baseUrl + 'api/transactions/all').subscribe(result => {
      this.transactions = result;
    }, error => console.error(error));
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }
}

interface Transaction {
  type: string;
  amount: number;
  date: Date;
  description: string;
}
