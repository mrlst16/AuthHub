import BootstrapVanilla from "./shared/bootstrap_vanilla";
import '../styles/homesplash.css'

export function HomeSplash(){
    return(
        <div className="container home_splash align-middle">
          <div className="row">
            <div className="col col-6">
              <div className="card">
                <div className="card-title text-center fs-1">Organization</div>
                <div className="card-body">
                  <div className="container">
                    <div className="row">
                      <div className="col col-6 text-center">
                        <a href="organization/signup">Sign Up</a>
                      </div>
                      <div className="col col-6 text-center">
                        <a href="organization/signin">Sign In</a>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="col col-6">
              <div className="card">
                <div className="card-title text-center fs-1">Members</div>
                <div className="card-body">
                  <div className="container">
                    <div className="row">
                      <div className="col col-6 text-center">
                        <a href="member/signup">Sign Up</a>
                      </div>
                      <div className="col col-6 text-center">
                        <a href="member/signin">Sign In</a>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        <BootstrapVanilla></BootstrapVanilla>
      </div>
    );
}