using UnityEngine;

// 이름 : 윤지영 
// 학번 : 201927060
public class Node<T>
{
    //NextNode : 다음 노드, value : 값
    private Node<T> nextNode;
    private T value;

    public Node(T value)
    {
        this.value = value;
    }
    //Get Set Get Set
    public void SetNextNode(Node<T> next)
    {
        this.nextNode = next;
    }
    public Node<T> GetNextNode()
    {
        return nextNode;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    public T GetValue()
    {
        return value;
    }
}
public class LinkedList<T>
{
    public Node<T> firstNode { get; set; } // 첫 노드
    public Node<T> lastNode { get; set; } // 마지막 노드
    public int nodeCnt; //노드 사이즈
    public LinkedList()
    {
        nodeCnt = 0;
    }
    public void CreateFirstNode(T value) //노드가 아예 없을 때 새로운 노드 생성
    {
        Node<T> tempNode = new Node<T>(value);
        firstNode = tempNode;
        lastNode = tempNode;
        nodeCnt++;
    }
    public void AddNodeFront(T value) //앞에 새로운 노드를 연결
    {
        if (nodeCnt == 0)
        {
            CreateFirstNode(value);
            return;
        }
        Node<T> tempNode = new Node<T>(value);
        tempNode.SetNextNode(firstNode);
        firstNode = tempNode;
        nodeCnt++;
    }
    public void AddNodeBehind(T value) //뒤에 새로운 노드를 연결
    {
        if (nodeCnt == 0)
        {
            CreateFirstNode(value);
            return;
        }
        Node<T> tempNode = new Node<T>(value);
        lastNode.SetNextNode(tempNode);
        lastNode = tempNode;
        nodeCnt++;
    }
    public void RemoveNodeFront() //앞에 있는 노드를 제거
    {
        if (nodeCnt == 0)
        {
            Debug.Log("ERROE 비어있는 링크드 리스트에서 노드를 삭제할 수 없습니다");
            return;
        }
        Node<T> nextNode = firstNode.GetNextNode();
        firstNode = nextNode;
        nodeCnt--;
    }
    public void RemoveNodeBehind() //뒤에 있는 노드를 제거
    {
        if (nodeCnt == 0)
        {
            Debug.Log("ERROE 비어있는 링크드 리스트에서 노드를 삭제할 수 없습니다");
            return;
        }
        Node<T> currentNode = firstNode;
        while (currentNode.GetNextNode() != lastNode)
        {
            currentNode = currentNode.GetNextNode();
        }
        lastNode = currentNode;
        nodeCnt--;
    }

}
public class Queue<T>
{
    private LinkedList<T> pizza; //피자
    public Queue()
    {
        pizza = new LinkedList<T>();
    }

    public void Enqueue(T value) //큐에 데이터 추가
    {
        pizza.AddNodeBehind(value);
    }
    public T Dequeue() //큐에서 데이터 팝
    {
        if (pizza.nodeCnt == 0)
        {
            Debug.Log("ERROR 비어있는 큐를 Dequeue할 수 없습니다");
            return default(T);
        }
        T result = pizza.firstNode.GetValue();
        pizza.RemoveNodeFront();
        return result;
    }
    public int Size() //큐의 사이즈 가져오기
    {
        return pizza.nodeCnt;
    }
    public T Peek() //Dequeue할 데이터를 미리보기
    {
        if (pizza.nodeCnt == 0)
        {
            Debug.Log("ERROR 비어있는 큐를 Peek할 수 없습니다");
            return default(T);
        }
        return pizza.firstNode.GetValue();
    }
}
public class LinkedListScript : MonoBehaviour
{
    //테스트
    private void Start()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        DisplayInfo(q);
        q.Dequeue();
        DisplayInfo(q);
        q.Enqueue(4);
        DisplayInfo(q);
        q.Dequeue();
        q.Dequeue();
        q.Dequeue();
        DisplayInfo(q);
        q.Dequeue();
        q.Dequeue();
        q.Dequeue();
        q.Dequeue();
        q.Dequeue();
        DisplayInfo(q);
    }

    public void DisplayInfo(Queue<int> q)
    {
        Debug.Log("큐 크기 : " + q.Size() + " 다음에 나올 데이터 : " + q.Peek());
    }
}