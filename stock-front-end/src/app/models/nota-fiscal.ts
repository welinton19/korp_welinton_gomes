export interface NotaFiscal {
  [x: string]: any;
  id: string;
  number: number;
  status: string;
  clientName: string;
  issueDate: string;
  issuerCnpj: string;
  recipientCnpj: string;
  totalValue: number;
  notaFiscalItens: NotaFiscalItem[];
}

export interface NotaFiscalItem {
  id: string;
  produtoId: string;
  codeProduto: string;
  quantity: number;
  unitPrice: number;
  notaFiscalId: string;
}
