import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CategoryService } from '../../services/categories/category.service';
import { CategoryDto } from '../../services/categories/models';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category',
  standalone: false,

  templateUrl: './category.component.html',
  styleUrl: './category.component.scss',
})
export class CategoryComponent implements OnInit {
  //#region Props
  categoryList!: CategoryDto[];

  @ViewChild('grid') grid!: ElementRef<HTMLDivElement>;
  @ViewChild('category') category!: ElementRef<HTMLDivElement>;
  //#endregion

  //#region Utils
  getCategoryList() {
    this.categoryService.getList().subscribe({
      next: (n) => (this.categoryList = n),
      error: (e) => console.log(e),
      // complete: () => ,
    });
  }
  //#endregion

  //#region Ctor
  constructor(
    private categoryService: CategoryService,
    private activatedRoute: ActivatedRoute
  ) {}
  //#endregion

  //#region Methods
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

  getHeader(): string {
    var header = '';
    this.activatedRoute.params.subscribe((params) => {
      var categoryId = parseInt(params['id']);

      if (categoryId === 0) header = ' Tüm Kategoriler';
      else if (categoryId > 0) {
        var category = this.categoryList.find((x) => x.id === categoryId);
        header = category!.name;
      }
    });

    return header;
  }

  getSubHeader() {
    var header = '';
    this.activatedRoute.params.subscribe((params) => {
      var categoryId = parseInt(params['id']);
      var subCategoryId = parseInt(params['sid']);

      if (categoryId === 0) header = 'Öne Çıkanlar';
      else if (categoryId > 0) {
        var category = this.categoryList.find((x) => x.id === categoryId);
        if (!Number.isNaN(subCategoryId))
          header = category!.subCategoryList.find(
            (x) => x.id === subCategoryId
          )!.name;
      }
    });

    return header;
  }

  categoryBtnOnClick() {
    this.category.nativeElement.classList.toggle('hidden');
    this.category.nativeElement
      .getElementsByTagName('button')[0]
      .classList.toggle('rotate');
    this.category.nativeElement
      .getElementsByClassName('category-list')[0]
      .classList.toggle('hidden');
  }

  subLiOnClick() {
    this.category.nativeElement.classList.add('hidden');
    this.category.nativeElement
      .getElementsByTagName('button')[0]
      .classList.add('rotate');
    this.category.nativeElement
      .getElementsByClassName('category-list')[0]
      .classList.add('hidden');
  }

  @HostListener('document:click', ['$event'])
  handleDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;

    if (this.category !== undefined)
      if (!this.category.nativeElement.contains(target)) {
        this.category.nativeElement.classList.add('hidden');
        this.category.nativeElement
          .getElementsByTagName('button')[0]
          .classList.add('rotate');
        this.category.nativeElement
          .getElementsByClassName('category-list')[0]
          .classList.add('hidden');
      }
  }

  @HostListener('document:scroll') scrolling() {
    this.category.nativeElement.classList.add('hidden');
    this.category.nativeElement
      .getElementsByTagName('button')[0]
      .classList.add('rotate');
    this.category.nativeElement
      .getElementsByClassName('category-list')[0]
      .classList.add('hidden');
  }
  //#endregion
}
