import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from '../../services/categories/category.service';
import { CategoryDto } from '../../services/categories/models';

@Component({
  selector: 'app-product',
  standalone: false,

  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
})
export class ProductComponent implements OnInit {
  categoryList!: CategoryDto[];

  @ViewChild('grid') grid!: ElementRef<HTMLDivElement>;

  getCategoryList() {
    this.categoryService.getList().subscribe({
      next: (n) => ((this.categoryList = n), console.log(n)),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategoryList();
  }

  toggleSubMenu(dropdownBtn: HTMLButtonElement) {
    if (!dropdownBtn.nextElementSibling!.classList.contains('show'))
      this.closeAllSubMenus();

    dropdownBtn.nextElementSibling!.classList.toggle('show');
    dropdownBtn.classList.toggle('rotate');

    if (this.grid.nativeElement.classList.contains('close')) {
      this.grid.nativeElement.classList.toggle('close');
    }
  }

  liOnClick(id: number) {
    console.log(id)
    Array.from(this.grid.nativeElement.getElementsByTagName('li')).forEach(
      (li) => {
        if (li.id === id.toString()) {
          li!.classList.add('active');
        } else {
          li!.classList.remove('active');
        }
      }
    );
  }

  closeAllSubMenus() {
    Array.from(this.grid.nativeElement.getElementsByClassName('show')).forEach(
      (ul) => {
        ul.classList.remove('show');
        ul.previousElementSibling!.classList.remove('rotate');
      }
    );
  }
}
