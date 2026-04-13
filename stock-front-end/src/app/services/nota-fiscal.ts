import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jsPDF from 'jspdf';
import { Observable } from 'rxjs';
import { NotaFiscal } from '../models/nota-fiscal';

@Injectable({
  providedIn: 'root',
})
export class NotaFiscalService {
  private apiUrl = 'http://localhost:5000/api/nota-fiscal/notafiscal';

  constructor(private http: HttpClient) {}

  
  getNotasFiscais(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  criaraNotaFiscal(nota: any): Observable<any> {
    return this.http.post(this.apiUrl, nota);
  }
  
  
  imprimirNota(id: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/imprimir`, {});
 }
  
  
  gerarPDF(nota: NotaFiscal): void {
   const doc = new jsPDF();

  
  doc.setFontSize(18);
  doc.setFont('helvetica', 'bold');
  doc.text('Nota Fiscal', 105, 20, { align: 'center' });

  
  doc.setLineWidth(0.5);
  doc.line(10, 25, 200, 25);

  
  doc.setFontSize(11);
  doc.setFont('helvetica', 'normal');
  doc.text(`Número: #${nota.number}`, 10, 35);
  doc.text(`Status: ${nota.status}`, 10, 43);
  doc.text(`Data: ${new Date().toLocaleDateString('pt-BR')}`, 10, 51);

  
  doc.line(10, 57, 200, 57);

  
  doc.setFont('helvetica', 'bold');
  doc.text('Produto', 10, 65);
  doc.text('Qtd', 130, 65);
  doc.text('Preço Unit.', 155, 65);
  doc.text('Total', 185, 65);

  doc.line(10, 68, 200, 68);

  
  doc.setFont('helvetica', 'normal');
  let y = 76;
  let totalGeral = 0;

  nota.notaFiscalItens?.forEach((item: any) => {
    const total = item.quantity * item.unitPrice;
    totalGeral += total;

    doc.text(`${item.produtoId}`, 10, y);
    doc.text(`${item.quantity}`, 130, y);
    doc.text(`R$ ${item.unitPrice.toFixed(2)}`, 155, y);
    doc.text(`R$ ${total.toFixed(2)}`, 185, y);
    y += 10;
  });

  
  doc.line(10, y, 200, y);
  y += 8;
  doc.setFont('helvetica', 'bold');
  doc.text(`Total Geral: R$ ${totalGeral.toFixed(2)}`, 185, y, { align: 'right' });

  
  doc.setFontSize(9);
  doc.setFont('helvetica', 'normal');
  doc.setTextColor(150);
  doc.text('Documento gerado automaticamente — Korp ERP', 105, 285, { align: 'center' });

  
  doc.save(`nota-fiscal-${nota.number}.pdf`);
}

}
