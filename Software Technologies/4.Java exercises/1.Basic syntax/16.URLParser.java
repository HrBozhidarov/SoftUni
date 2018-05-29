import java.util.Scanner;

public class URLParser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String url=scanner.nextLine();
        int endProtokol=url.indexOf("://");
        String protocol="";
        String server="";
        String resource="";

        if (endProtokol!=-1) {
            protocol=url.substring(0,endProtokol);
            url=url.substring(endProtokol+3);
        }

        int endServer=url.indexOf("/");

        if (endServer!=-1) {
            server=url.substring(0,endServer);
            resource=url.substring(endServer+1);
        }
        else {
            server=url;
        }

        System.out.printf("[protocol] = \"%s\"%n[server] = \"%s\"%n[resource] = \"%s\"%n"
                ,protocol,server,resource);
    }
}
