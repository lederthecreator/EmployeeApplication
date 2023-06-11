import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { GridModule, PagerModule, PageService, SortService, FilterService, ToolbarService, EditService } from '@syncfusion/ej2-angular-grids';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    GridModule, PagerModule
  ],
  providers: [PageService, SortService, FilterService, ToolbarService, EditService],
  bootstrap: [AppComponent]
})
export class AppModule { }
