import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Invoice, InvoiceStatus } from 'src/app/shared/models/invoice';
import { InvoiceService } from '../invoice.service';
import { concatWith } from 'rxjs';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  invoice?: Invoice;
  editForm: FormGroup;
  InvoiceStatus = InvoiceStatus;
  displayDate: string = "";
  
  submitted = false;

  constructor(
    private router: Router,
    private invoiceService: InvoiceService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      amount: ['', []],
      status: ['', []],
      invoiceDate: ['', []],
    });
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.getInvoice(params['id']);
    });
  }

  getInvoice(id: number) {
    this.invoiceService.getDetails(id).subscribe({
      next: (response: any) => {
        this.invoice = response;
        this.initializeForm();
      },
      error: (error: { error: any }) => {
        
      }
    });
  }

  updateInvoice() {
    this.submitted = true;

    if (this.editForm.valid) {
      const updatedInvoice: Invoice = {
        id: this.invoice?.id,
        amount: this.editForm.value.amount,
        status: parseInt(this.editForm.value.status, 10)
      };

      this.invoiceService.update(updatedInvoice).subscribe({
        next: (response: any) => {
          this.router.navigateByUrl('/invoice/list');
        },
        error: error => {
          
        }
      });
    }
  }

  initializeForm() {
    this.editForm.setValue({
      amount: this.invoice?.amount,
      status: this.invoice?.status,
      invoiceDate: this.invoice?.invoiceDate
    });
  }
}
