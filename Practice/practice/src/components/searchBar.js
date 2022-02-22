import { Input,Button,Form,Row,Col } from "reactstrap";
import { useState } from "react";
function SearchBar({click}){
const [search,setSearch] = useState("");

const handleChange = (e) => {
    setSearch(e.target.value)
}
    return(
        <Form>
        <Row className="mb-4 mt-2">
            <Col md='9'>
                     <Input className="form-control mr-sm-2 inline mx-5" type="search" onChange={handleChange} placeholder="Search" aria-label="Search"/>
            </Col>
            <Col md="2">
                <Button color="info" className="my-2 my-sm-0 mx-5" onClick={() => click(search)}>Search</Button>
            </Col>
            <Col md="1">
                <Input color="info" type="reset" value={"Clear"} onClick={() => click("")}></Input>
            </Col>
        </Row>
        </Form>
        
      
     
        
    );
}
export default SearchBar