export interface TodoItem {
    id: string;
    text: string;
    created: Date;
    completed?: Date;
}

export interface ErrorModel {
    title?: string;
    message: string;
}