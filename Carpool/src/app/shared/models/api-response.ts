export interface APIResponse<T>{
    
    data: T;
    statusCode:number;
    status:string;
    message:any;
    isSuccess:any;

}