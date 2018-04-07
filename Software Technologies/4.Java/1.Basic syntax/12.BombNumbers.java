import java.util.*;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine()
                .split(" "))
                .mapToInt(Integer::parseInt).toArray();

        int[] mine = Arrays.stream(scanner.nextLine()
                .split(" "))
                .mapToInt(Integer::parseInt).toArray();

        List<Integer> seq = new ArrayList<>();

        for (int i : numbers) {
            seq.add(i);
        }

        int bomb = mine[0];
        int range = mine[1];

        for (int i=0;i<seq.size();i++) {
            if (seq.get(i)==bomb) {

                int left=Math.max(i-range,0);
                int right=Math.min(i+range,seq.size()-1);

                for (int j=i;j>=left;j--) {
                  seq.set(j,0);
                }

                for (int j=i;j<=right;j++) {
                    seq.set(j,0);
                }
            }

            if(seq.size()==0) {
                break;
            }
        }

        int sum=0;

        for (int i=0;i< seq.size();i++){
            sum+=seq.get(i);
        }

        System.out.println(sum);
    }
}