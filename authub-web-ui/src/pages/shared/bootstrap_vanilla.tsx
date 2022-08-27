let usingBootstrap = false;

export default function BootstrapVanilla(){
    if(usingBootstrap) return(<span />);
    usingBootstrap = true;
    return (
        <div>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.2/js/bootstrap.min.js"></script>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"/>
        </div>          
    );
}