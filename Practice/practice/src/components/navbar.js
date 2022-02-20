import {Navbar,Nav,NavbarBrand,NavbarToggler,NavItem,NavLink,UncontrolledDropdown,DropdownToggle,DropdownItem,NavbarText,DropdownMenu,Collapse,Form,Input,Button} from 'reactstrap'

function NavigationBar(){
    return(
        <div>
  <Navbar
    color="info"
    expand="lg"
    light
    className='mb-3'
    container ='lg'
  >
    <NavbarBrand href="/">
      AuTOP
    </NavbarBrand>
    <NavbarToggler onClick={function noRefCheck(){}} />
    <Collapse navbar>
      <Nav
        className="me-auto"
        navbar
      >
        <NavItem>
          <NavLink href="/">
            Manufacturers
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink href="https://github.com/reactstrap/reactstrap">
            GitHub
          </NavLink>
        </NavItem>
        <UncontrolledDropdown
          inNavbar
          nav
        >
          <DropdownToggle
            caret
            nav
          >
            Options
          </DropdownToggle>
          <DropdownMenu end>
            <DropdownItem>
              Option 1
            </DropdownItem>
            <DropdownItem>
              Option 2
            </DropdownItem>
            <DropdownItem divider />
            <DropdownItem>
              Reset
            </DropdownItem>
          </DropdownMenu>
        </UncontrolledDropdown>
        <NavItem>
      <Form inline className="form-inline">
      <Input className="form-control mr-sm-2 inline mx-5" type="search" placeholder="Search" aria-label="Search"/>
    </Form>
      </NavItem>
      <NavItem>
        <Button className="my-2 my-sm-0 mx-5" type="submit">Search</Button>
      </NavItem>
      </Nav>
      
      <NavbarText>
        Simple Text
      </NavbarText>
    </Collapse>
  </Navbar>
</div>
    );
}

export default NavigationBar;