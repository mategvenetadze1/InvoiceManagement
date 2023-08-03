import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invoice } from '../shared/models/invoice';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http: HttpClient) { }

  getList(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${environment.appUrl}/api/invoices`);
  }

  getDetails(id?: number): Observable<Invoice> {
    return this.http.get<Invoice>(`${environment.appUrl}/api/invoices/${id}`);
  }

  update(invoice: Invoice): Observable<any> {
    return this.http.put(`${environment.appUrl}/api/invoices`, invoice);
  }

  delete(id?: number): Observable<any> {
    return this.http.delete(`${environment.appUrl}/api/invoices/${id}`);
  }

  create(invoice: Invoice): Observable<any> {
    return this.http.post(`${environment.appUrl}/api/invoices`, invoice);
  }

}
