import { Component } from "@angular/core";
import { ErrorModel } from "../core/models";

@Component({ template: '' })
export abstract class BaseComponent {
    public error: ErrorModel | undefined;

    handleError(message: string, title?: string): void {
        this.error = {
            title, message
        };
    }
}