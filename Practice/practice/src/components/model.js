import {Container} from 'reactstrap'

function Model(model){
    return(
        <Container className="bg-light border">
            <p>{model.Name}</p>
            <img src={model.ImageURL}></img>
        </Container>
    )
}

export default Model;