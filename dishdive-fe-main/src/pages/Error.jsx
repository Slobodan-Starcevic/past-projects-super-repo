import { useRouteError } from "react-router-dom"

export default function Error(){
    const error = useRouteError();
    console.error(error);

    return(
        <div id="error-page">
            <h1>Whoopsie!</h1>
            <p>An unexpected error has occurred.</p>
            <p>
                <i>{error.statusText || error.message}</i>
            </p>
        </div>
    )
}