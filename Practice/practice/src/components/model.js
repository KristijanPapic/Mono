import { Link } from 'react-router-dom';
import {Container} from 'reactstrap'
import '../App.css'

function Model(model){
    return(
        <Container className="bg-light border">
            {console.log(model)}
            <p><Link to={'/Model/' + model.model.Id}>{model.model.Name}</Link></p>
            <img className='mod_img' src={model.model.ImageURL}></img>
        </Container>
    )
}

export default Model;