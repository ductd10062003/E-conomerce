import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../service/product.service';
import { CategoryService } from '../../service/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  
  constructor(private a: CategoryService){}

  // products: any;

  ngOnInit(): void {
    // this.load();
  }

  // load(){
  //   this.productService.getAllProducts().subscribe(res =>{
  //     this.products = res;
  //   })
  // }

}
