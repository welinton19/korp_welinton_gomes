import { Component, signal } from '@angular/core';
import { ProdutosComponent } from './features/produtos/produtos.component';
import { AppRoutingModule } from "./app-routing-module";
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  imports: [ProdutosComponent, RouterOutlet, RouterLink, RouterLinkActive],
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('stock-front-end');
}
