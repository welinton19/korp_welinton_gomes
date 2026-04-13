import { Component, OnInit } from '@angular/core';
import { Produto } from '../../models/produtos';
import { ProdutosService } from '../../services/produtos';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produtos',
  standalone: true,
  imports:[CommonModule, FormsModule],
  templateUrl: './produtos.html',
  styleUrls: ['./produtos.css'],
})
export class ProdutosComponent implements OnInit {
  [x: string]: any;

  produtos: Produto[] = [];

  produto: any = {
    
    code: '',
    description: '',
    price: 0,
    balance: 0
  };

   constructor(private produtosService: ProdutosService,private router: Router) {}


    ngOnInit() {
      this.buscarProdutos();
  }

  buscarProdutos(){
    this.produtosService.getProdutos().subscribe({
      next: (res: Produto[]) => this.produtos = res,
      error: (err: any) => console.error(err)
    });
  }

  listarProdutos(): void {
    this.produtosService.getProdutos().subscribe({
      next: (res: Produto[]) => this.produtos = res,
      error: (err: any) => console.error(err)
    });

  }

  cadastrarProduto(): void {
    this.produtosService.criarProdutos(this.produto).subscribe({
      next: (res: Produto) => {
        console.log('Produto cadastrado:', res);
        console.log('OBJETO REAL:', this.produto);
        this.limparFormulario();
        this.listarProdutos(); 
      },
      error: (err: any) => console.error(err)
    });
  }

  deletarProduto(id: string): void {
  this.produtosService.deletarProduto(id).subscribe({
    next: () => {
      console.log('Produto deletado!');
      this.listarProdutos();
    },
    error: (err: any) => console.error(err)
  });
}


  limparFormulario(): void {
    this.produto = {
      id: 0,
      code: '',
      description: '',
      price: 0,
      balance: 0
    };
  }
   get produtosEmEstoque(): number {
    return this.produtos.filter(p => p.balance > 0).length;
  }

  get produtosEstoqueBaixo(): number {
    return this.produtos.filter(p => p.balance > 0 && p.balance <= 20).length;
 }
 
  irParaNotas(): void {
    this.router.navigate(['/notas-fiscais']);
 }

}


