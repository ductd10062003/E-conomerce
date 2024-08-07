import { Component } from '@angular/core';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-abc',
  templateUrl: './abc.component.html',
  styleUrl: './abc.component.css'
})
export class AbcComponent {
  constructor(private a: ProductService){}
}
