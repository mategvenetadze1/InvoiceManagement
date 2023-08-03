import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvoiceRoutingModule } from './invoice-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ListComponent } from './list/list.component';
import { NewComponent } from './new/new.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [
    ListComponent,
    NewComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule,
    SharedModule
  ]
})
export class InvoiceModule { }
