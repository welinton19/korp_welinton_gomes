import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { NotaFiscal } from '../../../models/nota-fiscal';
import { NotaFiscalService } from '../../../services/nota-fiscal';
import { Subject, takeUntil } from 'rxjs';


@Component({
  selector: 'app-gerar-notas',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './gerar-notas.html',
  styleUrl: './gerar-notas.css',
})
export class GerarNotasComponent implements OnInit, OnDestroy {

  
  notas: NotaFiscal[] = [];
  loading: boolean = false;
  loadingId: string | null = null;
  erro: string | null = null;

  private destrpoy$ = new Subject<void>();

  constructor(private notaFiscalService: NotaFiscalService) {}
  ngOnDestroy(): void {
    this.destrpoy$.complete();
  }

  ngOnInit(): void {
    this.listarNotas();
  }

  listarNotas(): void {
    this.notaFiscalService.getNotasFiscais()
    .pipe(takeUntil(this.destrpoy$))
    .subscribe({
      next: (res: NotaFiscal[]) => this.notas = res,
      error: (err: any) => console.error(err)
    });
  }

  imprimirNota(id: string): void {
    this.loading = true;
    this.loadingId = id;
    this.notaFiscalService.imprimirNota(id)
    .pipe(takeUntil(this.destrpoy$))
    .subscribe({
      next: () => {
        this.loading = false;
        this.loadingId = null;
      },
      error: (err: any) => {
        console.error(err);
        this.loading = false;
        this.loadingId = null;
      }
    });

  }

  Omdestroy(): void {
    this.destrpoy$.next();
    this.destrpoy$.complete();
  }

  baixarPDF(nota: NotaFiscal): void {
    this.notaFiscalService.gerarPDF(nota);
  }

}
