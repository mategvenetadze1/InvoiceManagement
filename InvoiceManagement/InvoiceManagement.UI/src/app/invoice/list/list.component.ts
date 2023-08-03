import { Component } from '@angular/core';
import { Invoice, InvoiceStatus } from 'src/app/shared/models/invoice';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  invoices: Invoice[] = [];

  constructor(
    private invoiceService: InvoiceService) {}

    ngOnInit(): void {
      this.getInvoices();
    }
  
    getInvoices(): void {
      this.invoiceService.getList().subscribe(
        (response: Invoice[]) => {
          this.invoices = response;
        },
        (error: any) => {
          
        }
      );
    }

    deleteInvoice(id?: number): void {
      this.invoiceService.delete(id).subscribe(
        () => {
          this.getInvoices();
        },
        (error: any) => {
   
        }
      );
    }

    getInvoiceStatusText(status?: InvoiceStatus): string {
      switch (status) {
        case InvoiceStatus.Draft: return 'Draft';
        case InvoiceStatus.Open: return 'Open';
        case InvoiceStatus.Paid: return 'Paid';
        case InvoiceStatus.Canceled: return 'Canceled';
        default: return '';
      }
    }

}
