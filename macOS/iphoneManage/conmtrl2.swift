//
//  conmtrl2.swift
//  iphoneManage
//
//  Created by Kira on 24.03.22.
//

import Cocoa

class conmtrl2: NSViewController {
    @IBOutlet weak var inputfield: NSTextField!
    @IBOutlet var packages: NSTextView!
    
    
    //sshpassPath path
    public let sshpassPath = "/Applications/iphoneManage.app/Contents/Resources/sshpass"
    public let iproxy = "/Applications/iphoneManage.app/Contents/Resources/iproxy"
    public let unneedirec = "/Users/*/"
    public let applicationrf = "/Applications/iphoneManage.app/Contents/"
    public let iManagerresources = "/Applications(iphoneManage.app/Contents/Resources"
    
    var sshpass: String = "alpine"
    var ipadress: String = "127.0.0.1"
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        kiracmlt(sshpassPath, "-p", sshpass, "ssh", "-o", "StrictHostKeyChecking=no", "-o", "UserKnownHostsFile=/dev/null", "root@\(ipadress)", "-p", "2222", "apt", "list", ">package.txt")
        kiracmlt(sshpassPath, "-p", sshpass, "scp", "-o", "StrictHostKeyChecking=no", "-o", "UserKnownHostsFile=/dev/null", "-r", "-P", "2222", "root@\(ipadress):/var/root/package.txt", "/Applications/iphoneManage.app/Contents/Resources/")
        let model1 = "/Applications/iphoneManage.app/Contents/Resources/package.txt"
        var data = try? String(contentsOfFile: model1,
                               encoding: String.Encoding(rawValue: String.Encoding.ascii.rawValue))

        // If a value was returned, print it.
        //print(data!)
        packages.string = data ?? "non connected"
        print(packages.string)
    }
    
    
    
    @IBOutlet var v: NSView!
    
    @IBAction func uninstsllPackage(_ sender: Any) {
        
        kiracmlt(sshpassPath, "-p", sshpass, "ssh", "-o", "StrictHostKeyChecking=no", "-o", "UserKnownHostsFile=/dev/null", "root@\(ipadress)", "-p", "2222", "apt", "remove", "\(inputfield.stringValue)")
    }
}
