export interface Invoice {
    id?: number;
    invoiceDate?: Date;
    status: InvoiceStatus;
    amount?: number;
}

export enum InvoiceStatus {
    Draft = 0,
    Open = 1,
    Paid = 2,
    Canceled = 3
}