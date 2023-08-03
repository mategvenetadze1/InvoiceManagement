import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Invoice, InvoiceStatus } from 'src/app/shared/models/invoice';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  errorMessages: string[] = [];
  invoice?: Invoice;
  newForm: FormGroup;
  InvoiceStatus = InvoiceStatus;

  submitted = false;

  constructor(
    private invoiceService: InvoiceService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.newForm = this.formBuilder.group({
      amount: ['', []],
      status: ['', []]
    });
  }

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.newForm.reset();
  }

  create() {
    this.submitted = true;
    this.errorMessages = [];

    if (this.newForm.valid) {
      const newInvoice: Invoice = {
        amount: this.newForm.value.amount,
        status: parseInt(this.newForm.value.status, 10)
      };

      this.invoiceService.create(newInvoice).subscribe({
        next: (response: any) => {
          this.router.navigateByUrl('/invoice/list');
        },
        error: error => {
          
        }
      });
    }
  }
}
