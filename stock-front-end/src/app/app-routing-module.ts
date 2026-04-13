import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GerarNotasComponent } from './features/nota-fiscal/gerar-notas/gerar-notas';
import { ProdutosComponent } from './features/produtos/produtos.component';

export const routes: Routes = [
   {
          path: '',
          redirectTo: 'produtos',
          pathMatch: 'full'
      },
      {
          path: 'produtos',
          component: ProdutosComponent
      },
      {
          path: 'notas-fiscais',
          component: GerarNotasComponent
      }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
